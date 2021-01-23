cs
BsonClassMap.RegisterClassMap<TestClass>(cm =>
{
    cm.AutoMap();
    var memberMap = cm.GetMemberMap(x => x.DictionaryField);
    var serializer = memberMap.GetSerializer();
    if (serializer is IDictionaryRepresentationConfigurable dictionaryRepresentationSerializer)
        serializer = dictionaryRepresentationSerializer.WithDictionaryRepresentation(DictionaryRepresentation.ArrayOfDocuments);
    memberMap.SetSerializer(serializer);
});
Or as an extention method:
cs
BsonClassMap.RegisterClassMap<TestClass>(cm =>
{
    cm.AutoMap();
    cm.SetDictionaryRepresentation(x => x.DictionaryField, DictionaryRepresentation.ArrayOfDocuments);
});
public static class MapHelpers
{
    public static BsonClassMap<T> SetDictionaryRepresentation<T, TMember>(this BsonClassMap<T> classMap, Expression<Func<T,TMember>> memberLambda, DictionaryRepresentation representation)
    {
        var memberMap = classMap.GetMemberMap(memberLambda);
        var serializer = memberMap.GetSerializer();
        if (serializer is IDictionaryRepresentationConfigurable dictionaryRepresentationSerializer)
            serializer = dictionaryRepresentationSerializer.WithDictionaryRepresentation(representation);
        memberMap.SetSerializer(serializer);
        return classMap;
    }
}
