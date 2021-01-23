    for (int i = 0; i < productsArray.GetLength(0); i++)
            {
                for (int j = 0; j < productsArray.GetLength(1); j++)
                {
                    Console.Write("Enter value for " + j.ToString() + " of week " + i.ToString() + " ==>  ");
                    string value=Console.ReadLine();
                    int intVal=0;
                    if (int.TryParse(value, out intVal))
                    {
                        productsArray[i, j] = intVal;
                    }
                    else
                    {
                        j--;
                    }
                }
