    public static IQueryable<MyModelDTO> ToModelDTO(this IQueryable<MyModel> query)
    {
        return query.Select(x => new MyModelDTO()
        {
            MyPropOne = (int)x.MyModel.MyOtherPropOne,
            MyPropTwo = x.MyOtherPropTwo ?? 0,
            MyPropThree = x.MyModel.MyOtherPropThree,
            MyPropFour = x.MyModel.MyOtherPropFour,
            MyPropFive = x.MyModel.Entity.MyOtherPropFive,
            MyPropSix = x.MyModel.MyOtherPropSix == null ? 0 : (decimal)x.MyModel.MyOtherPropSix,
            MyPropSeven = x.MyModel.SomeType.MyOtherPropSeven,
            MyPropEight = (int)x.MyModel.MyOtherPropEight,
            MyPropNine = x.MyModel.MyPropNine == null ? 0 : (int)x.MyModel.MyOtherPropNine,
            MyPropTen = x.MyModel.MyOtherPropTen == null ? 0 : (int)x.MyModel.MyOtherPropTen,
            MyPropEleven = x.OtherEntity.MyOtherPropEleven,
            MyPropTwelve = x.MyOtherpropTwelve
        });
    }
