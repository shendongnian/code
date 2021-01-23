    public interface IPartyRepository
    {
        Task<IEnumerable<Party>> GetAll(out long partyCount);
        Task<IEnumerable<Party>> SearchByNameAndNotes(string searchTerm);
    }
