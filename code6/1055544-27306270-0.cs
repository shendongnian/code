        class Entry
        {
            [CsvColumn(FieldIndex = 1, Name="row")]
            public long Id { get; set; }
            [CsvColumn(FieldIndex = 2)]
            public string Guid { get; set; }
            [CsvColumn(FieldIndex = 3)]
            public int Grouping1 { get; set; }
            [CsvColumn(FieldIndex = 4)]
            public int Grouping2 { get; set; }
            [CsvColumn(FieldIndex = 5)]
            public int Metric1 { get; set; }
            [CsvColumn(FieldIndex = 6)]
            public double Metric2 { get; set; }
        }
