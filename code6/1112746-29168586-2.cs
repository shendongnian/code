        [Route("user/{userId}/feeds/async")]
        [HttpGet]
        public async Task<IEnumerable<NewsFeedItem>> GetNewsFeedItemsForUserAsync(string userId)
        {
            return await _newsFeedService.GetNewsFeedItemsForUser(userId);
        }
