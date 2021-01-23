    static async Task<Sheet> GetMaterialDrawingAsync(ProcessedParts processedParts)
    {
      var list = await MaterialsList.Manager.GetMaterialListAsync(processedParts);
      return await list.GetDrawingAsync();
    }
