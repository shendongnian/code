    using System;
    using System.Net;
    
    namespace CTCServer
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Set title
                Console.Title = "CTC-Server";
    
                //Create new instance of the server
                Server server = new Server(IPAddress.Any, 1221);
    
                //Handle GotDataFromCTC
                server.GotDataFromCTC += GotDataFromCTC;
    
                //Start the server. We could use the autoStart in constructor too.
                server.Run();
    
                //Inform about the running server
                Console.WriteLine("Server running");
    
    
                //Listen for input.
                while(true)
                {
                    //Read input line from cmd
                    string input = Console.ReadLine();
                    
                    //Stores the command itself
                    string command;
    
                    //Stores parameters
                    string param  = "";
    
                    //If input line contains a whitespace we have parameters that need to be processed.
                    if(input.Contains(" "))
                    {
                        //Split the command from the parameter. Parte before whitespace = command, rest = parameters
                        command = input.Split(' ')[0];
                        param = input.Substring(command.Length +1);
                    }
                    else
                    {
                        //No whitespace, so we dont have any parameters. Use whole input line as command.
                        command = input;
                    }
    
                    //Process the command
                    switch(command)
                    {
                        //Sends a string to all clients. Everything behind "send " (Note the whitespace) will be send to the client. Exanple "send hello!" will send "hello!" to the client.
                        case "send":
                        {
                            //Give some feedback
                            Console.WriteLine("Send to all clients: {0}", param);
                            
                            //Send data
                            server.SendToAll(param);
                            
                            //Done
                            break;
                        }
    
                        //Closes connection to all clients and exits. No parameters.
                        case "exit":
                        {
                            //Stop the server. This will disconncet all clients too.
                            server.Stop();
    
                            //Clean exit
                            Environment.Exit(0);
                            
                            //Done. We wont get here anyway.
                            break;
                        }
                    }
                }
            }
    
            //Recived data from clien. Show it!
            static void GotDataFromCTC(object sender, string data)
            {
                Console.WriteLine("Data from CTC-Server with ID {0} recived:\r\n{1}", (sender as Client).id, data);
            }
        }
    }
