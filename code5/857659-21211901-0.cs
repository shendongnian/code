        /*Propmt user for beverages*/
        while (!bool_valid)
        {
            bool_valid = true;
            Console.WriteLine("Plesae Choose a Drink; Press 1 for Coke, Press 2 for Sprite, Press 3 for Dr.Prpper");
            try
            {
                int_bvg_type = Convert.ToInt32(Console.ReadLine());
                if(!(int_bvg_type > 0 && int_bvg_type < 4)){
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("PLease enter a Number between 1 and 3");
                bool_valid = false;
            }
        }
