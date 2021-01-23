    public async Task<BaseResponse<DocumentState>> GetById(string id)
        {
            try
            {
                _answer.SingleResult = await Session.LoadAsync<DocumentState>(id);
                _answer.Success = true;
            }
            catch (Exception ex)
            {
                _answer.ErrorResponse = ex;
            }
            return _answer;
        }
