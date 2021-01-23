    for (int i = 0; i < arregloDif.Length; i++)
                {
                    listaDif.Add(new Bitmap(/*AppDomain.CurrentDomain.BaseDirectory + @"Diferentes\\" + */arregloDif[i]));
                }
    
                for (int i = 0; i < arregloIguales.Length; i++)
                {
                    listaIgual.Add(new Bitmap(/*AppDomain.CurrentDomain.BaseDirectory + @"Iguales\\" + */arregloIguales[i]));
                }
    
                for (int i = 0; i < arregloOriginales.Length; i++)
                {
                    listaOriginales.Add(new Bitmap(/*AppDomain.CurrentDomain.BaseDirectory + @"Originales\\" + */arregloOriginales[i]));
                }
