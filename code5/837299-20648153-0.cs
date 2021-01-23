    public Map(int w, int h, int num) {
      Width = w; Height = h; Ships = num;
      for (int i = 0; i < h; i++) {
        List<bool> row = new List<bool>();
        for (int i = 0; i < w; i++) row.Add(false);
        ShipPos.Add(row);
      }
    }
