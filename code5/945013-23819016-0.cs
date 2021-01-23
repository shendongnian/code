    Dictionary<int, TextBox> dic = new Dictionary<int, TextBox>();
    dic.Add(1, textBox1);
    dic.Add(2, textBox2);
    int input = int.Parse(Console.ReadLine());
    if (dic.ContainsKey(input))
       Console.WriteLine(dic[input].Text);
    else
       Console.WriteLine("No box found!");
