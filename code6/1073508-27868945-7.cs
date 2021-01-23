    _standing a = new _standing("James", 2);
    _standing b = new _standing("Mark", 0);
    _standing c = new _standing("John", 1);
    _standing[] standing = new _standing[] { a, b, c };
    listBox1.Items.AddRange(standing.OrderBy(i => i.position).ToArray());
