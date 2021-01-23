static void Main(string[] args)
{
    String add = "Mr John Smtih";
    Console.WriteLine(add);
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < add.Length; i++)
    {
        if (add[i].Equals(' '))
        {
            sb.Append("%20");
        }
        else
        {
            sb.Append(add[i]);
        }
    }
    Console.WriteLine(add);
    Console.WriteLine(sb);
    Console.ReadLine();
}
