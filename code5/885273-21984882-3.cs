    private bool AreAllProperValuesSelected()
    {
        var list = new List<DropDownList>
                       {
                           r1,
                           r2,
                           r3,
                           r4,
                           r5,
                           r6,
                           r7,
                           r8,
                           g1,
                           g2,
                           g3,
                           g4,
                           g5,
                           g6,
                           g7,
                           g8,
                           b1,
                           b2,
                           b3,
                           b4,
                           b5,
                           b6,
                           b7,
                           b8
                       };
        return list.TrueForAll(item => item.SelectedIndex != 0);
    }
