    string s = "What is the Price of Dell Inspiration 4 #1989768733736 Please reply as soon as possible";
    int index = s.IndexOf("#");
    s = s.Substring(index);
    string number = s.Split(null)[0];
    Console.WriteLine(number); // #1989768733736         
