    public List<List<Product>> GetAffordableCombinations(double availableMoney, List<Product> availableProducts)
    {
        List<Product> sortedProducts = availableProducts.OrderByDescending(p => p.Price).ToList();
        
        List<int> layerPointer = new List<int>();
        layerPointer.Add(0);
        int currentLayer = 0;
        List<List<Product>> affordableCombinations = new List<List<Product>>();
        List<Product> tempList = new List<Product>();
        while (layerPointer[0] < sortedProducts.Count)
        {
            var currentProduct = sortedProducts[layerPointer[currentLayer]];
            var currentSum = tempList.Sum(p => p.Price);
            if ((currentSum + currentProduct.Price) <= availableMoney)
            {
                tempList.Add(currentProduct);
                currentLayer++;
                if (currentLayer >= layerPointer.Count)
                    layerPointer.Add(layerPointer[currentLayer - 1]);
            }
            else
            {
                layerPointer[currentLayer]++;
                if (layerPointer[currentLayer] >= sortedProducts.Count)
                {
                    affordableCombinations.Add(tempList);
                    tempList = new List<Product>();
                    layerPointer[0]++;
                    currentLayer = 0;
                    for (int i = 1; i < layerPointer.Count; i++)
                    {
                        layerPointer[i] = layerPointer[0];
                    }
                }
            }
        }
        return affordableCombinations;
    }
