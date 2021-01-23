    public static bool AreJsonObjectsEqual(DynamicJsonObject obj1, DynamicJsonObject obj2)
    {
        var memberNamesNotEqual = obj1.GetDynamicMemberNames().Except(obj2.GetDynamicMemberNames()).Any();
        if (!memberNamesNotEqual)
        {
           dynamic dObj1 = (dynamic)obj1;
           dynamic dObj2 = (dynamic)obj2;
           foreach (var memberName in obj1.GetDynamicMemberNames()){
               if(dObj1[memberName] != dObj2[memberName]) return false
           }
           return true
        }
        return memberNamesNotEqual;
    }
