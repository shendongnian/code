    var model = TypeModel.Create();
    // The first parameter (maps to ProtoContractAttribute) is the Type to be included.
    // The second parameter determines whether to apply default behavior,
    // based on the attributes. Since we're not using those, this has no effect.
    model.Add(typeof(Fred), false);
    model.Add(typeof(Middle), false);
    model.Add(typeof(Top), false);
    // The newly added MetaTypes can be accessed through their respective Type indices.
    //   The first parameter is the unique member number, similar to ProtoMemberAttribute.
    //   The second parameter is the name of the member as it is declared in the class.
    //   When the member is a list:
    //     The third parameter is the Type for the items.
    //     The fourth parameter is the Type for the list itself.
    model[typeof(Fred)].Add(1, "Name");
    model[typeof(Middle)].Add(1, "Freds", typeof(Fred), typeof(Fred[]));
    model[typeof(Top)].Add(1, "Middle");
    model[typeof(Top)].Add(2, "Freds", typeof(Fred), typeof(Fred[]));
