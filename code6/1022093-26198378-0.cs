    Dictionary<Int, Set<Int>> results;
    Set<Int> getResult(int index) {
      Set<Int> dictResult = results.get(index);
      if(dictResult != null) {
        // result has already been computed
        return dictResult;
      } else {
        // compute result, store in dictResult
        Set<Int> newResult = // compute dependency set
        dictResult.put(index, newResult);
        return newResult;
      }
    }
