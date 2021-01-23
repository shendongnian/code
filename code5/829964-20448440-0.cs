    int[] add = new[] {100000, 50000, 500, 20000, 10000, 50000};
    bool[] check = new[] {radBrick.Checked, chkBasketball.Checked, chkFire.Checked, chkMarble.Checked, chkSteel.Checked, chkGarage.Checked};
    int sum = 0;
    for (int i = 0 ; i != add.Length ; i++) {
        if (check[i]) {
            sum += add[i];
        }
    }
