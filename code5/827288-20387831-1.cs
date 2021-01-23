public static ObjectSet&lt;T> Cast&lt;T>(this ObjectQuery objectSet)
{
  if(!(objectSet is ObjectSet&lt;T>))
    throw new Exception("Invalid instance passed or entity type specified");
  return objectSet as ObjectSet&ltT>;
}
