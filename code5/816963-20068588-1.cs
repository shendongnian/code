    // I'm making up "ArtistType", fix according to your actual code
    class ArtistTypeEqualityComparer : IEqualityComparer<ArtistType>
    {
        public bool Equals(ArtistType x, ArtistType y)
        {
            if (ArtistType.ReferenceEquals(x, null)) return false;
            if (ArtistType.ReferenceEquals(y, null)) return false;
            if (ArtistType.ReferenceEquals(x, y)) return true;
            return x.ArtistTypeId.Equals(y.ArtistTypeId);
        }
        public int GetHashCode(ArtistType obj)
        {
            return obj.ArtistTypeId.GetHashCode();
        }
    }
    // And then the "add" part simplifies
    artist.ArtistTypes.AddRange(this._db.ArtistTypes.Intersect(vm.SelectedIds.Select(x => new ArtistType{ ArtistTypeId = x }));
