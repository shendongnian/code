    public class UserCharacterDto // short version
    {
        public virtual int Id { get; set; }
        public virtual string Nickname { get; set; }
        public virtual int? XP { get; set; }
        public virtual int? ClassId { get; set; }
    }
    public class UserDto // short version
    {
        public virtual string Nickname { get; set; }
        // Changed from ISet: you don't have a key!
        public virtual IList<CharacterDto> Characters { get; set; }
    }
    public class CharacterDto // short version
    {
        public virtual int XP { get; set; }
        public virtual int ClassId { get; set; }
    }
