    Class KittenDto {
        public static Expression<Func<Db.Kitten, KittenDto>> = (kitten) => return new KittenDto() {
            Id = Id,
            Name = Name,
            CustomDataNotInDb = 42
        };
        public int Id;
        public string Name;
        public int CustomDataNotInDb;
    }
