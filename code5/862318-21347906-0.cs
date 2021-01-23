    var data = from at in answerText.AsEnumerable()
               join qa in questionAvg.AsEnumerable() on at.Field<int>("ID") equals qa.Field<int>("DealerID")
               join inter in interviews.AsEnumerable() on at.Field<int>("ID") equals inter.Field<int>("DealerID")
               select new
               {
                   DealerID = at.Field<int>("ID"),
                   DealerName = at.Field<string>("Name"),
                   AnswerText1 = at.Field<int?>("12") ?? 0,                           
                   AnswerText2 = at.Field<int?>("8") ?? 0,
                   AnswerText3 = at.Field<int?>("4") ?? 0,
                   AnswerText4 = at.Field<int?>("0") ?? 0,
                   AnswerText5 = at.Field<int?>("-4") ?? 0,
                   Rank = qa.Field<Int64?>("Rank"),
                   Average = qa.Field<decimal?>("Average"),
                   N = inter.Field<int?>("N")
               };
