    var output = new[] { 0, 1, 2, 68, 69, 70, 254, 255 };
    var binary = new List<byte>();
    foreach(int val in output){
        binary.Add((byte)val);
    }
    var result = Convert.ToBase64String(binary.ToArray());
