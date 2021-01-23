    using System;
    using System.Text;
    using System.Net.Sockets;
    using System.Collections.Generic;
    namespace MyNamespace.Utilities
    {
            public class StateObject{
                public Socket workSocket = null;
                public const int BUFFER_SIZE = 1024;
                public byte[] buffer = new byte[BUFFER_SIZE];
                //public StringBuilder message = new StringBuilder();
            }
            public class FullDuplexSocket : IDisposable
            {
                public event NewMessageHandler OnMessageReceived;
                public delegate void NewMessageHandler(string Message);
                public event DisconnectHandler OnDisconnect;
                public delegate void DisconnectHandler(string Reason);
                private Socket _socket;
                private bool _useASCII = true;
                private string _remoteServerIp = "";
                private int _port = 0;
                private bool _allowRetry = true;
                /// <summary>
                /// Constructer of a full duplex client socket.   The consumer should immedately define 
                /// and event handler for the OnMessageReceived event after construction has completed.
                /// </summary>
                /// <param name="RemoteServerIp">The remote Ip address of the server.</param>
                /// <param name="Port">The port that will used to transfer/receive messages to/from the remote IP.</param>
                /// <param name="UseASCII">The character type to encode/decode messages.  Defaulted to use ASCII, but setting the value to false will encode/decode messages in UNICODE.</param>
                public FullDuplexSocket(string RemoteServerIp, int Port, bool UseASCII = true)
                {
                    _useASCII = UseASCII;
                    _remoteServerIp = RemoteServerIp;
                    _port = Port;
                    Initialize();
                }
                private void Initialize()
                {
                    try //to create the socket and connect
                    {
                        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        _socket.Connect(_remoteServerIp, _port);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Unable to connect to the remote Ip.", e);
                    }
                    try //to listen to the socket
                    {
                        StateObject stateObject = new StateObject();
                        stateObject.workSocket = _socket;
                        _socket.BeginReceive
                            (
                                stateObject.buffer, //Buffer to load in our state object
                                0, //Start at the first position in the byte array
                                StateObject.BUFFER_SIZE, //only load up to the max per read
                                0, //Set socket flags here if necessary 
                                new AsyncCallback(ReadFromSocket), //Who to call when data arrives
                                stateObject //state object to use when data arrives
                            );
                        _allowRetry = true;
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Unable to start listening to the socket.", e);
                    }
                }
                /// <summary>
                /// This will read the bytes from the socket, convert the bytes to a string and fire the OnMessageReceived event.
                /// If the socket is forcibly closed, the OnDisconnect event will be fired.   This happens when the other side of
                /// the socket connection on the remote Ip is no longer available.
                /// </summary>
                /// <param name="asyncResult"></param>
                public void ReadFromSocket(IAsyncResult asyncResult)
                {
                    StateObject stateObject = (StateObject)asyncResult.AsyncState; //pull out the state object
                    int bytesReceived = 0;
                    try //to receive the message.
                    {
                        bytesReceived = stateObject.workSocket.EndReceive(asyncResult); 
                    }
                    catch (Exception e)  //Exception will occur if connection was forcibly closed.
                    {
                        RaiseOnDisconnect(e.Message);
                        return;
                    }
                    if (bytesReceived > 0)
                    {
                        RaiseOnMessageReceived
                            (
                                _useASCII ?
                                    Encoding.ASCII.GetString(stateObject.buffer, 0, bytesReceived) :
                                    Encoding.Unicode.GetString(stateObject.buffer, 0, bytesReceived)
                            );
                        try  //The BeginRecieve can file due to network issues.   _allowRetry allows a single failure between successful connections.
                        {
                            if (_allowRetry)
                            {
                                stateObject.workSocket.BeginReceive
                                    (
                                        stateObject.buffer, //Buffer to load in our state object
                                        0, //Start at the first position in the byte array
                                        StateObject.BUFFER_SIZE, //only load up to the max per read
                                        0, //Set socket flags here if necessary 
                                        new AsyncCallback(ReadFromSocket), //Who to call when data arrives
                                        stateObject //state object to use when data arrives
                                    );
                            }
                        }
                        catch
                        {
                            _allowRetry = false;
                        }
                    }
                    else
                    {
                        stateObject.workSocket.Close();
                        RaiseOnDisconnect("Socket closed normally.");
                        return;
                    }
                }
                /// <summary>
                /// Broadcast a message to the IP/Port.  Consumer should handle any exceptions thrown by the socket.
                /// </summary>
                /// <param name="Message">The message to be sent will be encoded using the character set defined during construction.</param>
                public void Send(string Message)
                {
                    //all messages are terminated with /r/n
                    Message += Environment.NewLine;
                    byte[] bytesToSend = _useASCII ?
                        Encoding.ASCII.GetBytes(Message) :
                        Encoding.Unicode.GetBytes(Message);
                    int bytesSent = _socket.Send(bytesToSend);
                }
                /// <summary>
                /// Clean up the socket.
                /// </summary>
                void IDisposable.Dispose()
                {
                    try
                    {
                        _socket.Close();
                        RaiseOnDisconnect("Socket closed via Dispose method.");
                    }
                    catch { }
                    try
                    {
                        _socket.Dispose();
                    }
                    catch { }
                }
                /// <summary>
                /// This method will gracefully raise any delegated events if they exist.
                /// </summary>
                /// <param name="Message"></param>
                private void RaiseOnMessageReceived(string Message)
                {
                    try //to raise delegates
                    {
                        OnMessageReceived(Message);
                    }
                    catch { } //when none exist ignore the Object Reference Error
                }
                /// <summary>
                /// This method will gracefully raise any delegated events if they exist.
                /// </summary>
                /// <param name="Message"></param>
                private void RaiseOnDisconnect(string Message)
                {
                    try //to raise delegates
                    {
                        OnDisconnect(Message);
                    }
                    catch { } //when none exist ignore the Object Reference Error
                }
            }
    }
