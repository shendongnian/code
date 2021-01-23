    for (int i = 1; i > 0; i++)
        {
            Console.Write("\n\nQue letra desea jugar : ");
            letra_insertada = Convert.ToChar(Console.ReadLine());
            for (int j = 0; j < oracionChar.Length; j++)
            {
                if (oracionChar[j] != letra_insertada)
                {
                    desasiertos = aciertos - 1; //lives
                    printWord();                      
                }
                if (oracionChar[j] == letra_insertada)
                {
                    letracorrecta[j] = letra_insertada]; //inserting the correct word
                    printWord();
                }
            }
        }
