        for (int i = 1; i <= value; i++)
        {
            if (i % 3 == 0)
            {          
                ViewBag.Output += "Fizz ";
                if (i % 5 == 0)
                    ViewBag.Output += "Buzz ";             
            }
            else if (i % 5 == 0)
            {
                ViewBag.Output += "Buzz "
            }
            else // neither divided by 3 nor by 5
            {
               ViewBag.Output += i.ToString() + " ";
            }
        }
