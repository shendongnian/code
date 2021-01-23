    int position = 0;
    int veces = 0;
    string temp = ""
    for (int i = 0; i < m.Length; i++) {
      if (Char.IsDigit(m[i]))
        position = i;
      else
        break;
    }
    veces = Convert.ToInt32(m.SubString(0, i + 1));
