        using System;
    
    public class Program
    {
    	public static void Main()
    	{		
    		var bcTxt = "0000420876802";
    		int prod1 = 0;
                int prod2 = 0;
                string Txt1 = "";
                string Txt2 = "";
    
                Txt1 = bcTxt;
                // Berechnen der Prüfziffer, wenn ungerade Anzahl von Zeichen
                if (Txt1.Length % 2 == 1)
                {
                    for (int i = 0; i < Txt1.Length; i++)
                    {
                        prod1 += int.Parse(Txt1.Substring(i, 1)) * 3;
                        if (i > Txt1.Length -1)
                        {
                            prod1 += int.Parse(Txt1.Substring(i + 1, 1));
                        }
                        i += 1;
                    }
                    prod2 = prod1 % 10;
                    if (prod2 == 0) prod2 = 10;
    				prod2 = 10 - prod2;
                    Txt1 += (char)(prod2 + 48);
                }
                //Ascii Zeichen zuordnen
                //beim Code 2/5 werden die Zeichen paarweise zugeordnet
                Txt2 = ((char)34).ToString();
                string Tmp = "";
                for (int i = 0; i < Txt1.Length; i++)
                {
    				Console.WriteLine(Txt1);				
                    Tmp += Txt1.Substring(i, 2);
    				Console.WriteLine(Tmp);
                    i += 1;
                    if (int.Parse(Tmp) > 91)
                    {
                        Txt2 += ((char)(int.Parse(Tmp) + 70)).ToString();
                    }
                    else
                    {
                        Txt2 += ((char)(int.Parse(Tmp) + 36)).ToString();
                    }
                    Tmp = "";
                }
    
                Txt2 += ((char)35).ToString();
    		Console.WriteLine(Txt2);
    	}
    }
