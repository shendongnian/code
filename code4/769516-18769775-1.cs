        while (true)
        {
            packet = Console.ReadLine();
            packet += "<EOF>";
            Send(sock, packet);
            Receive(sock);
            connectDone.WaitOne();
        }
