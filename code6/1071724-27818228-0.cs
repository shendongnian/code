            static void Main(string[] args)
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("myusername@gmail.com", "mypwd"),
                    EnableSsl = true
                };
                client.Send("myusername@gmail.com", "myusername@gmail.com", "test", "testbody");
                Console.WriteLine("Sent");
                Console.ReadLine();
            }
