public class Organisation
{
    public Organisation()
    {
        Children = new Collection&lt;Organisation>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Organisation Parent { get; set; }
    public virtual ICollection&lt;Organisation> Children { get; set; }
}
