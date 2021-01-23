    double salconv = 0; ;
    string linha, salario = "";
    string[] maior = new string[100];
    StreamReader sr = new StreamReader(@"C:\Users\pw\Downloads\data.txt");
    while (!sr.EndOfStream)
    {
        linha = sr.ReadLine();
        string nomes = linha.Substring(53, 52);
        salario = sr.ReadLine();
        if (Double.TryParse(salario.Substring(156, 6), out salconv))
        {
            Console.WriteLine(salconv);
        }
    }
    sr.Close();
    Console.ReadKey();
