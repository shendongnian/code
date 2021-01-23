    using System;
    public class Test
    {
        public static void Main()
        {
            new Test().button1_Click(null, null);
        }
        int rc;
        double centro, centro1;
        int r2, c2, rc2;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string textBoxContents = "9";
                rc = Convert.ToInt16(textBoxContents);
                if (rc == 3 || rc == 5 || rc == 7 || rc == 9 || rc == 11)
                {
                    centro = rc / 2;
                    centro1 = Math.Round(centro, 0);
                    int[,] dim = new int[rc, rc];
                    int v = 1, r = 0, c, x = 0;
                    c = Convert.ToInt16(centro1);
                    //rc2 = rc;
                    for (x = 0; x < (rc*rc); x++)
                    {
                        if (dim[r, c] >= 1)
                        {
                            r = r2 + 2;
                            c = c2 - 1;
                            dim[r, c] = v;
                        }
                        else
                        {
                            dim[r, c] = v;
                        }
                        c++;
                        r--;
                        v++;
                        if (r < 0)
                        {
                            r = rc -1;
                        };
                        if (c > (rc-1))
                        {
                            c = 0;
                        };
                        r2 = r;
                        c2 = c;
                    }
                    string matrixString = "";
                    for (int i = 0; i < dim.GetLength(0); i++)
                    {
                        for (int j = 0; j < dim.GetLength(1); j++)
                        {
                            matrixString += dim[i, j].ToString();
                            matrixString += " ";
                        }
                        matrixString += Environment.NewLine;
                    }
                    Console.WriteLine(matrixString);
                }
                else
                {
                    Console.WriteLine("***Else***   Verifica que:\n- Introduzcas   solo digitos.\n- Introduzcas solo numeros inpares\ndentro de las demensiones indicadas.\n- Solo introduzcas el numero de\nrenglones o columnas.");
                }
            }
            catch
            {
                Console.WriteLine("***Exception***   Verifica que:\n- Introduzcas solo      digitos.\n- Introduzcas solo numeros inpares\ndentro de las demensiones indicadas.\n- Solo introduzcas el numero de\nrenglones o columnas.");
            }
        }
    }
