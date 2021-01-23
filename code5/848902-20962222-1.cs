        private void CatchReceivedEvents(object src, SerialDataReceivedEventArgs e)
        {
            SerialDataReceivedEventHandler eventHandler = DataReceived;
            SerialStream stream = internalSerialStream;
            if ((eventHandler != null) && (stream != null)){
                lock (stream) {
                    // SerialStream might be closed between the time the event runner
                    // pumped this event and the time the threadpool thread end up
                    // invoking this event handler. The above lock and IsOpen check
                    // ensures that we raise the event only when the port is open
                    bool raiseEvent = false;
                    try {
                        raiseEvent = stream.IsOpen && (SerialData.Eof == e.EventType || BytesToRead >= receivedBytesThreshold);
                    }
                    catch {
                        // Ignore and continue. SerialPort might have been closed already!
                    }
                    finally {
                        if (raiseEvent)
                            eventHandler(this, e);  // here, do your reading, etc.
                    }
                }
            }
        }
