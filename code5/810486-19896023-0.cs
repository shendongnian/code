    var readers = new List<FileReader>();    
    System.IO.File.ReadAllLines(@"C:\Files\Archivo.txt").ToList()
    .ForEach(l => { 
        string[] splitted = l.Split(','); 
        readers.Add(new FileReader(){ 
            Matricula = splitted[0], 
            Nombre = splitted[1], 
            Sueldo = decimal.Parse(splitted[2])
        }); 
    });
