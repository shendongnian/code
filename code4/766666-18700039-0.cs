    int type = 5; //integer
    if (nombreMayusculas.Contains("SERVICE"))
    {
        int a = 0;
        int.TryParse(nombreMayusculas.Replace("SERVICE", ""), out a);
        
        //You cannot use Equals here.. used only for string comparison
        if (a == type))
        {
            //some logic here to process only the matching Xmlnode
        }
    }
