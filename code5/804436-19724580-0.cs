        while ((Content = SR.ReadLine()) != null)
        {
            if (Content.Contains(Name))
            {
                Console.WriteLine("Found");
            }
        }
