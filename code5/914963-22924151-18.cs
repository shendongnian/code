    public interface IPartyRepository
    {
        Task<IEnumerable<Party>> GetAllAsync(out long partyCount);
        Task<IEnumerable<Party>> SearchByNameAndNotesAsync(string searchTerm);
    }
