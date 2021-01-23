    [HttpPost]
    public CarInputCharacteristicsDTO PostCharacteristics([FromBody]CarInputCharacteristicsDTO characteristics)
    {
        return characteristics;
    }
