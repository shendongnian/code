    for (int i = page.Cells.Count - 1; i >= 0; i--)
    {
        if (page.Cells[i].RowNum == RowNum)
        {
            unitOfWork.CellRepository.Delete(page.Cells[i]);
        }
    }
