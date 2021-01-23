    //A simple, custom router
    public class CustomRouter : DirectInterfaceIOHandler
    {
        //Is called for each frame - place your logic here. 
        protected override void HandleTraffic(Frame fInputFrame)
        {
            //Get the IP frame
            //IPv4Frame ipv4frame = GetIPv4Frame(fInputFrame);
            IPFrame ipframe = GetIPFrame(fInputFrame);
            if (ipframe != null)
            {
                //Iterate over all interfaces.
                foreach (IPInterface ipInterface in lInterfaces)
                {
                    //Adjust this condition to check whether ipInterface is the correct interface for this frame
                    if (true)
                    {
                        //With this overload of send, the interface handles hardware addressing. 
                        ipInterface.Send(fInputFrame, ipframe.DestinationAddress);
                    }
                }
            }
        }
    }
