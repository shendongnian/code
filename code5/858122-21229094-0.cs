    // copied from UIDragObject.UpdateBounds()
    public static Bounds GetContentRectBounds(UIRect content, UIPanel uiPanel){
      Matrix4x4 toLocal = uiPanel.transform.worldToLocalMatrix;
      Vector3[] corners = content.worldCorners;
      for( int i = 0; i < 4; ++i ){
        corners[i] = toLocal.MultiplyPoint3x4(corners[i]);
      }
      Bounds mBounds = new Bounds(corners[0], Vector3.zero);
      for( int i = 1; i < 4; ++i ){
        mBounds.Encapsulate(corners[i]);
      }
      return mBounds;
    }
