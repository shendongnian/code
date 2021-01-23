    public async Task<int> CountMyJobsAsync(string name)
    {
        using (WindowsIdentity.GetCurrent().Impersonate())
        {
            return await _jobRepository.Where(i => i.Name == name).CountAsync()
                .ConfigureAwait(false);
        }
    }
