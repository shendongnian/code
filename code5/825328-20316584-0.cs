    string s = "Summary Symptoms Read More Summary A tarsal coalition is a bridge of bone that forms in the foot in late adolescence. As the tarsal coalition progresses from a fibrous...";
    int firstindex = s.IndexOf("Summary ");
    s = s.Remove(0, 8);
    int secondindex = s.IndexOf("Summary ");
    Console.WriteLine(s.Substring(secondindex + 8));
