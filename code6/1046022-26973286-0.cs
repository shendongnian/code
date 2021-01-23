    public ICollection<UserDto> GetUsersByFilter(string filter)
    {
    	var addressBooksRepository = new AddressBooksRepository();
    	var addressBookEntries = addressBooksRepository.GetAll().Where(filter);
    			//return data
    }
