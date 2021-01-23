    int x;
    
    string[] b = new string[5];
    
    b[0] = "Tukul";
    b[1] = "Dedy";
    b[2] = "Aldi";
    b[3] = "Anang";
    b[4] = "Aconk";
    
    Console.WriteLine(b[0] + " " + b[1] + " " + b[2] + " " + b[3] + " " + b[4]);
    Console.WriteLine("Masukan Huruf awal yang ingin dicari : ");
    string nama = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Nama yang ditemukan !!");
    
    foreach (var apa in Array.FindAll(b, element => element.StartsWith(nama, StringComparison.OrdinalIgnoreCase)))
    {
    	Console.WriteLine("".PadLeft(10, '='));
    	Console.WriteLine(apa);
    	Console.WriteLine("".PadLeft(10, '='));
    }
