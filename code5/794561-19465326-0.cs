    for (var blockRow = 0 ; blockRow < rows ; blockRow += 8) {
        for (var blockCol = 0 ; blockCol < yLimit ; blockCol += 8) {
            for (var r = 0 ; r != 8 ; r++) {
                for (var c = 0 ; c != 8 ; c++) {
                    imageBlock[r][c] = image_array[0].Data[blockRow+r, blockCol+c, 1];
                }
            }
            blockList.Add(ForwardDCT(imageBlock));
        }
    }
