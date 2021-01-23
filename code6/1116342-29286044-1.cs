    using UnityEngine;
    using System.Collections;
    
    public class Grid : MonoBehaviour {
        // The Grid itself
        public static int w = 10;
        public static int h = 20;
        public static Transform[,] grid = new Transform[w, h];
    
        public static Vector2 roundVec2(Vector2 v) {
            return new Vector2(Mathf.Round(v.x),
                               Mathf.Round(v.y));
        }
        public static void deleteRow(int y) {
            for (int x = 0; x < w; ++x) {
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
            }
        }
        public static void decreaseRow(int y) {
            for (int x = 0; x < w; ++x) {
                if (grid[x, y] != null) {
                    // Move one towards bottom
                    grid[x, y-1] = grid[x, y];
                    grid[x, y] = null;
    
                    // Update Block position
                    grid[x, y-1].position += new Vector3(0, -1, 0);
                }
            }
        }
        public static void decreaseRow(int y) {
            for (int x = 0; x < w; ++x) {
                if (grid[x, y] != null) {
                    // Move one towards bottom
                    grid[x, y-1] = grid[x, y];
                    grid[x, y] = null;
    
                    // Update Block position
                    grid[x, y-1].position += new Vector3(0, -1, 0);
                }
            }
        }
        public static void decreaseRow(int y) {
            for (int x = 0; x < w; ++x) {
                if (grid[x, y] != null) {
                    // Move one towards bottom
                    grid[x, y-1] = grid[x, y];
                    grid[x, y] = null;
    
                    // Update Block position
                    grid[x, y-1].position += new Vector3(0, -1, 0);
                }
            }
        }
        public static bool isRowFull(int y) {
            for (int x = 0; x < w; ++x) {
                if (grid[x, y] == null)
                    return false;
            }
            return true;
        }
        public static void deleteFullRows() {
            for (int y = 0; y < h; ++y) {
                if (isRowFull(y)) {
                    deleteRow(y);
                    decreaseRowsAbove(y+1);
                    --y;
                }
            }
        }
    }
