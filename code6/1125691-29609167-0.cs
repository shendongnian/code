    foreach (FieldInfo memberAField in classA.GetType().GetFields()) {
        Console.WriteLine(memberAField.Name + " " + memberAField.MemberType + " " + memberAField.FieldType);
        object memberAValue = memberAField.GetValue(classA);  // instance to call GetValue on later.
        foreach (PropertyInfo classAProperty in memberAField.FieldType.GetProperties()) {
            Console.WriteLine("name: " + classAProperty.Name);
            Console.WriteLine(" to value: " + classAProperty.GetValue(memberAValue));
            }
        }
