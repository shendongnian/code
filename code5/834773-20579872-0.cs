            Complex temp = null;
            try
            {
                Console.Write("Enter input: ");
                string input = Console.ReadLine();
                String[] cplx = input.Split(' ');
                if (cplx.Length != x)
                    throw new Exception("INVALID INPUT ENTRY...");
                temp = new Complex(Double.Parse(cplx[0]), Double.Parse(cplx[1]));
            }
            catch (Exception)
            {
                Console.WriteLine("INVALID INPUT ENTRY...");
            }
