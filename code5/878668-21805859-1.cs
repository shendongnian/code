    Update<Game>(new
    {
        gameUpdateDto.Name,
        gameUpdateDto.HasStarted,
        gameUpdateDto.HasEnded
    }, g => g.Id == gameUpdateDto.Id);
