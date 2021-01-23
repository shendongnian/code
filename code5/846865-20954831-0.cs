    [Test]
    public void LeftOuterProjection()
    {
        using (var s = OpenSession())
        using (var t = s.BeginTransaction())
        {
            // Set up aliases to use in the queryover.
            KeyDTO dtoAlias = null;
            Key keyAlias = null;
            Translation translationAlias = null;
            var results = s.QueryOver<Key>(() => keyAlias)
                .JoinAlias(k => k.Translations, () => translationAlias, JoinType.LeftOuterJoin)
                .Where(() => translationAlias.LanguageId == 6)
                .OrderBy(() => keyAlias.KeyName).Asc
                .Select(Projections.Property(() => keyAlias.KeyName).WithAlias(() => dtoAlias.KeyName),
                        Projections.Property(() => translationAlias.TranslationString).WithAlias(() => dtoAlias.TranslationString),
                        Projections.Property(() => translationAlias.Comments).WithAlias(() => dtoAlias.Comments))
                .TransformUsing(Transformers.AliasToBean<KeyDTO>())
                .List<KeyDTO>();
        }
    }
    public class KeyDTO
    {
        public string KeyName { get; set; }
        public string TranslationString { get; set; }
        public string Comments { get; set; }
    }
    public class Key
    {
        public int Id { get; set; }
        public string KeyName { get; set; }
        public IList<Translation> Translations { get; set; }
    }
    public class Translation
    {
        public Key Key { get; set; }
        public int LanguageId { get; set; }
        public string TranslationString { get; set; }
        public string Comments { get; set; }
    }
