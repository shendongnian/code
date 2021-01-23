    public interface IPartyRepository
    {
        IEnumerable<Party> GetAll(out long partyCount);
        IEnumerable<Party> SearchByNameAndNotes(string searchTerm);
    }
