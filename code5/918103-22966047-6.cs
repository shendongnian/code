    private Task<string[][]> ArrayMaker(uint x, uint y)
    {
        var result = new string[x][]
        for (var i = 0; i < x; i++)
        {
            result[i] = new string[y];
            for (var j = 0; j < y; j++)
            {
                result[i][j] = ((long)i * j).ToString(CultureInfo.InvariantCulture);
            }
        }
        return result;
    }
    private async void btn_Click(object sender, EventArgs e)
    {
        var bigArray = await ArrayMaker(1000000, 1000000);
    }
