            for (int counti = 0; counti < countt; counti++)
            {
                byte[] toadd = new byte[7000];
                richTextBox1.Invoke((MethodInvoker)delegate { richTextBox1.AppendText("Counti = " + counti.ToString() + "\n"); });
                Client.Receive(toadd);
                writer.Write(toadd,0,toadd.Count());
                neededbytes.AddRange(toadd);
                filesize -= 7000;
            }
