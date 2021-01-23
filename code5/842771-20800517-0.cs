      // To prevent candidate_list repainting while items updating
      candidate_list.BeginUpdate();
      try {
        // When using RemoveAt() one should use backward loop 
        for (int i = candidate_list.SelectedIndices.Count - 1; i >= 0; --i) {
          int index = candidate_list.SelectedIndices[i];
          candidate_list.Items.RemoveAt(index);
          candidates.RemoveAt(index); 
        }
      }
      finally {
        candidate_list.EndUpdate();
      }
