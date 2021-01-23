        public override void borrowCopy()
        {
            if (AvailCopies > 0)
            {
                AvailCopies--;
                Console.Write("Please refer to receipt for return date of the Movie\n");
            }
            else
            {
                Console.WriteLine("\nThis Movie is not available at this time, please try again later");
            }
        }
