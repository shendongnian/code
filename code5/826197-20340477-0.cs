        public void Writrline()
        {
            Square item = head; // Store the head - so you can modify it below
            while (item != null)
            {
                Console.WriteLine(item.p);
                item = item.next; // Move to next item in the list
            }
            Console.ReadKey(); // Read after the loop to pause (if you want to do this)
        }
