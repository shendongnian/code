    class ColumnIndex {
        int NameIndex {get;set;}
        int AgeIndex {get;set;}
        int DateIndex {get;set;}
        int ScoreIndex {get;set;}
    }
    private static readonly ColumnIndex[] ColIndex = new[] {
        new ColumnIndex  {NameIndex = 6, AgeIndex = 2, DateIndex = 4, ScoreIndex = 7}
    ,   new ColumnIndex  {NameIndex = 9, AgeIndex = 1, DateIndex = 0, ScoreIndex = 3}
    ,   new ColumnIndex  {NameIndex = 5, AgeIndex = 8, DateIndex = 2, ScoreIndex = 1}
    ,   ...
    };
    ...
    int caseSwitch = -1;
    if (radioButton1.Checked == true)
    {
        caseSwitch = 0;
    }
    else if (radioButton2.Checked == true)
    {
        caseSwitch = 1;
    }
    else if (radioButton3.Checked == true)
    {
        caseSwitch = 2;
    }
    var query = from x in Data
        select new {
            Name  = x[ColIndex[caseSwitch].NameIndex]
        ,   Age   = x[ColIndex[caseSwitch].AgeIndex]
        ,   Date  = x[ColIndex[caseSwitch].DateIndex]
        ,   Score = x[ColIndex[caseSwitch].ScoreIndex]
        };
